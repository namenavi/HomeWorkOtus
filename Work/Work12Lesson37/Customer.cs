using System.Collections.Specialized;

namespace Work12Lesson37
{
    class Customer
    {
       public void OnItemChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if(e.NewItems?[0] is Product newProduct)
                        Console.WriteLine($"Добавлен новый объект: ID - {newProduct.Id}, Name - {newProduct.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if(e.OldItems?[0] is Product oldProduct)
                        Console.WriteLine($"Удален объект:  ID - {oldProduct.Id}, Name - {oldProduct.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    if((e.NewItems?[0] is Product replacingProduct)  &&
                        (e.OldItems?[0] is Product replacedProduct))
                        Console.WriteLine($"Объект: ID - {replacedProduct.Id}, Name - {replacedProduct.Name}, заменен объектом: ID - {replacingProduct.Id}, Name - {replacingProduct.Name}");
                    break;
            }
        }
    }
}
