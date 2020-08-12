namespace NOP.COMMERCE.WEB.AT.GUI.Utils
{
    public interface IPdfGenerator
    {
        void AddText(string text);
        void TakeScreenshot();
        void GeneratePdf();
    }
}