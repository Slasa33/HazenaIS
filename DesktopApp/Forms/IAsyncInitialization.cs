using System.Threading.Tasks;

namespace DesktopApp.Forms
{
    public interface IAsyncInitialization
    {
        Task Initialization { get; }
    }
}