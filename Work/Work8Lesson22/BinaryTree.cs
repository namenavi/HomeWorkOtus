namespace Work8Lesson22
{
    /// <summary>
    /// (binary tree) – это структура данных, которая состоит из узлов, при этом каждый узел может иметь не более двух дочерних.
    /// Первый узел называется корневым или родительским, а дочерние – правым и левым наследником(потомком).
    /// </summary>
    public class BinaryTree
    {
        /// <summary>
        /// Корень бинарного дерева
        /// </summary>
        public BinaryTreeNode RootNode { get; set; }
        /// <summary>
        /// Добавление нового узла в бинарное дерево
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="salary">Сумма зарплаты</param>
        public void Add(string name, int salary)
        {
            RootNode = Add(RootNode, name, salary);
        }
        /// <summary>
        /// Добавление нового узла в бинарное дерево
        /// </summary>
        /// <param name="root">корень бинарного дерева</param>
        /// <param name="name">Имя</param>
        /// <param name="salary">Сумма зарплаты</param>
        /// <returns>Возвращает корень бинарного дерева</returns>
        private BinaryTreeNode Add(BinaryTreeNode root, string name, int salary)
        {
            if(root == null)
            {
                root = new BinaryTreeNode(name, salary);
                return root;
            }

            if(salary < root.Salary)
            {
                root.Left = Add(root.Left, name, salary);
            }
            else if(salary >= root.Salary)
            {
                root.Right = Add(root.Right, name, salary);
            }

            return root;
        }
        /// <summary>
        /// Вывести данные в порядке возрастания
        /// </summary>
        /// <param name="node">Элемент дерева</param>
        public void InAscOrder(BinaryTreeNode node)
        {
            if(node != null)
            {
                InAscOrder(node.Left);
                Console.WriteLine($"{node.Name} - {node.Salary}");
                InAscOrder(node.Right);
            }
        }
        /// <summary>
        /// Вывести данные в порядке убывания
        /// </summary>
        /// <param name="node">Элемент дерева</param>
        public void InDescOrder(BinaryTreeNode node)
        {
            if(node != null)
            {
                InDescOrder(node.Right);
                Console.WriteLine($"{node.Name} - {node.Salary}");
                InDescOrder(node.Left);
            }
        }
        /// <summary>
        /// Поиск сотрудника с указанной зарплатой и выводит его имя. 
        /// </summary>
        /// <param name="targetSalary">Сумма для поиска</param>
        /// <returns>Имя сотрудника. Если сотрудник не найден - выводится "Такой сотрудник не найден"</returns>
        public string SearchBySalary(int targetSalary)
        {
            return SearchBySalary(RootNode, targetSalary);
        }
        /// <summary>
        /// Поиск сотрудника с указанной зарплатой и выводит его имя в переданном корневом элементе. 
        /// </summary>
        /// <param name="node">Корневой элемент.</param>
        /// <param name="targetSalary">Сумма поиска</param>
        /// <returns>Имя сотрудника. Если сотрудник не найден - выводится "Такой сотрудник не найден"</returns>
        private string SearchBySalary(BinaryTreeNode node, int targetSalary)
        {
            if(node == null)
            {
                return "Такой сотрудник не найден";
            }

            if(targetSalary == node.Salary)
            {
                return node.Name;
            }

            if(targetSalary < node.Salary)
            {
                return SearchBySalary(node.Left, targetSalary);
            }
            else
            {
                return SearchBySalary(node.Right, targetSalary);
            }
        }
    }
}
