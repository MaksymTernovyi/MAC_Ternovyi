namespace MAC_DLL
{
    public class MAC_Function_Table_Node
    {
        public double X { get; }
        public double F { get; }

        public MAC_Function_Table_Node(double x, double f) => (X, F) = (x, f);

        public string ToPrint() => $"   ({X,16:F10},{F,16:F10}   )";
    }
}