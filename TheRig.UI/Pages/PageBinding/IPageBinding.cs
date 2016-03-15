using TheRig.UI.Controller;

namespace TheRig.UI.Pages.PageBinding
{

    public interface IPageBinding
    {
        void ExecuteInput(string key);
        GameController GameController { get; set; }
    }
}
