using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareQ.Quiz.Server.Resources
{
    public class HostResources : IHostResources
    {
        public List<Resource> Resources => new List<Resource>()
        {
            new Resource { ResourceType = ResourceType.Stylesheet, Url = "_content/BlazorAnimation/" + "animate.css" },
            new Resource { ResourceType = ResourceType.Script, Url = "_content/BlazorAnimation/" + "blazorAnimationInterop.js" }
        };
    }
}
