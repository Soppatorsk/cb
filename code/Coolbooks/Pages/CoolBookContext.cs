using Coolbooks.Models;

namespace Coolbooks.Pages
{
    internal class CoolBookContext
    {
        public IEnumerable<Book> Books { get; internal set; }
    }
}