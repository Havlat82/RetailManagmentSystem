using Caliburn.Micro;
using System.ComponentModel;
using System.Threading.Tasks;

namespace RetailManagmentSystem.WPF_UI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }



        public string SubTotal
        {
            //TODO: Pak to nahradit výpočtem
            get => "$10.00";
        }



        public string Tax
        {
            //TODO: Pak to nahradit výpočtem
            get => "$10.00";

        }



        public string Total
        {
            //TODO: Pak to nahradit výpočtem
            get => "$10.00";

        }

        public bool CanAddToCart
        {
            get
            {
                return true;// je vybrán alespoň jeden prvek z Products
            }
        }

        public async Task AddToCart()
        {
            //TODO: Pak to nahradit skutečným zdrojákem

            //ErrorMessage = "";

            //try
            //{
            //    var result = await _apiHelper.Authenticate(Username, Password);
            //    ErrorMessage = "Jsi přihlášen";
            //    await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

            //}
            //catch (Exception ex)
            //{
            //    ErrorMessage = $"Nejsi přihlášen: {ex.Message}";
            //}

        }

        public bool CanRemoveFromCart
        {
            get
            {
                return Cart != null && Cart.Count > 0;
            }
        }

        public async Task RemoveFromCart()
        {
            //TODO: Pak to nahradit skutečným zdrojákem

            //ErrorMessage = "";

            //try
            //{
            //    var result = await _apiHelper.Authenticate(Username, Password);
            //    ErrorMessage = "Jsi přihlášen";
            //    await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

            //}
            //catch (Exception ex)
            //{
            //    ErrorMessage = $"Nejsi přihlášen: {ex.Message}";
            //}

        }

        public bool CanCheckOut
        {
            get
            {
                return true;// je něco v cart
            }
        }

        public async Task CheckOut()
        {
            //TODO: Pak to nahradit skutečným zdrojákem

            //ErrorMessage = "";

            //try
            //{
            //    var result = await _apiHelper.Authenticate(Username, Password);
            //    ErrorMessage = "Jsi přihlášen";
            //    await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

            //}
            //catch (Exception ex)
            //{
            //    ErrorMessage = $"Nejsi přihlášen: {ex.Message}";
            //}

        }
    }
}
