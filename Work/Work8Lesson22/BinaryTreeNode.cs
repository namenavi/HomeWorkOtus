namespace Work8Lesson22
{
    /// <summary>
    /// Узел бинарного дерева для характеристики сотрудника
    /// </summary>
    public class BinaryTreeNode
    {
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Зарплата сотрудника
        /// </summary>
        public int Salary { get; set; }
        /// <summary>
        /// Левая ветка
        /// </summary>
        public BinaryTreeNode Left { get; set; }
        /// <summary>
        /// Правая ветка
        /// </summary>
        public BinaryTreeNode Right { get; set; }
        /// <summary>
        /// Узел бинарного дерева для характеристики сотрудника
        /// </summary>
        public BinaryTreeNode(string name, int salary)
        {
            Name = name;
            Salary = salary;
            Left = null;
            Right = null;
        }
    }
}
