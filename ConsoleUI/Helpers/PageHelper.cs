using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.Pages;
using ConsoleUI.PageLayout;

namespace ConsoleUI.Helpers
{
    public static class PageHelper
    {
        private const string CHOOSE_PAGE = "Wybierz jedna z akcji: ";

        public static T ReadInput<T>(string msg)
        {
            if (msg == null)
                throw new ArgumentNullException("msg");

            Console.Write(msg);
            string input = Console.ReadLine();
            try
            {
                var castedVal = (T)Convert.ChangeType(input, typeof(T));
                return castedVal;
            }
            catch(Exception)
            {
                return default(T);
            }
        }

        public static int ChoosePage()
        {
            return ReadInput<int>(CHOOSE_PAGE);   
        }


        public static bool GoToPage(PageLayoutManager manager, IList<IPage> pageConnection, object obj)
        {
            int page = (int)obj;
            if (page < 1 || page > pageConnection.Count)
                return false;

            try
            {
                var nextPage = pageConnection[page - 1];
                manager.Show(nextPage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
