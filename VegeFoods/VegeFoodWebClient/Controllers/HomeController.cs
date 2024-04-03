using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using VegeFoodAPI.Models;
using VegeFoodWebClient.Models;
using VegeFoodWebClient.SessionExtensions;

namespace VegeFoodWebClient.Controllers
{
    public class HomeController : Controller
    {
        public static string productByIdUrl = "http://localhost:5104/api/Product/GetProductById/";
        private readonly ILogger<HomeController> _logger;
        public static Product product { get; set; }
        public List<Product> cart { get; set; }
        //câu lệnh để dùng được sesstion
        public readonly IHttpContextAccessor contxt;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            contxt = httpContextAccessor;
            _logger = logger;
        }

        public IActionResult Index(string logout)
        {
           if(logout == "true")
            {
                HttpContext.Session.Remove("User");
                return View();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login(string message)
        {
            if(message != null)
            {
                ViewData["message"] = message;
            }
            else
            {
                ViewData["message"] = "";
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser(string userName, string password)
        {
            var userCredentials = new
            {
                UserName = userName,
                Password = password
            };
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(userCredentials), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:5104/api/Login", stringContent))
                {

                    string token = await response.Content.ReadAsStringAsync();
                    if (token == "Invalid Credentials")
                    {
                        return Redirect("~/Home/Login?message=Incorrect userName or Password!");
                    }

                    HttpContext.Session.SetString("JWToken", token);
                }

            }
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JWToken"));
                using (var response = await httpClient.GetAsync("http://localhost:5104/api/User/SearchUserByUserName/" + userName + ""))
                {

                    User user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());


                    HttpContext.Session.SetObject("User", user);
                   
                }
            }
            return Redirect("~/Home/Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Shop(int productId)
        {

            if (productId != 0)
            {
                await GetProductByidAsync(productId);
                if (contxt.HttpContext.Session.GetObject<List<Product>>("cart") == null)
                {
                    cart = new List<Product>();
                    contxt.HttpContext.Session.SetObject("cart", cart);
                }
                AddToCart(product, 1);
            }

            return View();
        }

        public async Task<IActionResult> SingleProduct(int productId, string quantity)
        {
            int q = 0;
            if (quantity != null)
            {
                q = Int32.Parse(quantity);
            }

            ViewData["productId"] = productId;
            if (productId != 0)
            {
                await GetProductByidAsync(productId);
                if (contxt.HttpContext.Session.GetObject<List<Product>>("cart") == null)
                {
                    cart = new List<Product>();
                    contxt.HttpContext.Session.SetObject("cart", cart);
                }
                AddToCart(product, q);
            }
            return View();
        }

        public IActionResult Cart(int pIdToDelete)
        {
            if (pIdToDelete != 0)
            {
                cart = contxt.HttpContext.Session.GetObject<List<Product>>("cart");
                Product itemToRemove = cart.Single(r => r.ProductId == pIdToDelete);
                cart.Remove(itemToRemove);
                contxt.HttpContext.Session.SetObject("cart", cart);

            }
            return View();
        }

        public IActionResult Checkout(decimal totalMoney)
        {
            ViewBag.TotalMoney = totalMoney;
            return View();
        }


        public IActionResult ProductManagement()
        {
            return View();
        }
        public IActionResult UserManagement()
        {
            return View();
        }
        public IActionResult OrderManagement()
        {
            return View();
        }
        public void AddToCart(Product product, int q)
        {
            var res = product;
            bool exist = false;
            cart = contxt.HttpContext.Session.GetObject<List<Product>>("cart");
            foreach (Product temproduct in cart)
            {
                if (temproduct.ProductId == product.ProductId)
                {

                    temproduct.UnitInStock += q;
                    exist = true;
                    break;
                }
            }
            if (cart.Count == 0)
            {

                Product temp = new Product();
                temp = res;
                temp.UnitInStock = q;
                cart.Add(temp);
            }

            else if (cart.Count > 0 && exist == false)
            {


                Product temp = new Product();
                temp = res;
                temp.UnitInStock = q;

                cart.Add(temp);


            }
            contxt.HttpContext.Session.SetObject("cart", cart);


        }
        public async Task GetProductByidAsync(int productId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JWToken"));
            var url = productByIdUrl + productId.ToString();
            string jsonStr = await httpClient.GetStringAsync(url);
            var res = JsonConvert.DeserializeObject<Product>(jsonStr);
            product = res;
        }

        public IActionResult OrderDetails(int orderId)
        {
            ViewData["orderIdDetail"] = orderId;
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult UpdateProduct(int productId)
        {
            ViewData["productId"] = productId;
            return View();
        }

        public IActionResult ManageUserDetails(int accountId)
        {
            ViewData["accountId"] = accountId;
            return View();
        }

        public IActionResult EditOrder(int orderId)
        {
            ViewData["orderId"] = orderId;
            return View();
        }

        public IActionResult UserProfile(int accountId)
        {
            ViewData["AccountId"] = accountId;
            return View();
        }    

        public IActionResult ViewMyOrders(int accountId)
        {
            ViewData["AccountId"] = accountId;
            return View();
        }

        public IActionResult CustomerOrderDetails(int orderId)
        {
            ViewData["orderId"] = orderId;
            return View();
        }
    }
}
