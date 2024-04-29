namespace homework_7
{
    internal interface IFigureBuilder
    {
        IInputParser InputParser { get; }
        IFigure Build();
    }
}
