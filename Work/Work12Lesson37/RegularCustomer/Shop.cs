using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Work12Lesson37.RegularCustomer
{
    class Shop : INotifyCollectionChanged
    {
        ObservableCollection<Product> list = new ObservableCollection<Product>();
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public Shop()
        {
            list.CollectionChanged += List_CollectionChanged;
        }
        /// <summary>
        /// Метод вызова внешних подписчиков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void List_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(sender, e);
        }


        /// <summary>
        /// добавления товара
        /// </summary>
        /// <param name="product">товар для добавления</param>
        public void Add(Product product)
        {
            list.Add(product);
        }
        /// <summary>
        /// удаления товара
        /// </summary>
        /// <param name="productID">ID товарa для удаления</param>
        public void Remove(int productID)
        {
            var temp = list.Where(x => x.Id == productID).FirstOrDefault();
            if (temp != null)
            {
                list.Remove(temp);
            }
            else
            {
                Console.WriteLine("Неверный ID товара. Такого товара нет.");
            }
        }
        /// <summary>
        /// Вывести товары находящиеся в магазине
        /// </summary>
        public void SelectProducts()
        {
            Console.WriteLine($"Товарна складе в количестве: {list.Count}");
            foreach (Product product in list)
            {
                Console.WriteLine($"Товар:  ID - {product.Id}, Name - {product.Name}");
            }
        }
    }
}
