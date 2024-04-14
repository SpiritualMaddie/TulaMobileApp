using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tula.Model
{
    public partial class ChatMessage : ObservableObject
    {
        [ObservableProperty]
        public string? text;
    }
}
