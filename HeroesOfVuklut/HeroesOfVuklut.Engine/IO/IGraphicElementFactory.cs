namespace HeroesOfVuklut.Engine.IO
{
    public interface IGraphicElementFactory
    {
        IListElement<T> CreateListElement<T>() where T : class;
        ISliderElement<T> CreateSliderElement<T>() where T : class;
        IGraphicButton CreateButton(ButtonType buttonType);
        ITextBoxElement CreateTextBox(KeyboardType keyboardType);
    }


    public enum ButtonType
    {
        Rectangle,
        Circle
    }
}
