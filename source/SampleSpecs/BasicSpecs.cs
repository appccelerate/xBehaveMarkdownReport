using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSpecs
{
    using Xbehave;

    public class BasicSpecs
    {
        [Scenario]
        public void ThisIsAScenario()
        {
            "establish something"._(() => { });

            "when doing something"._(() => {  });

            "it should be this"._(() => { });

            "it should not be that"._(() => { });
        }

        [Scenario]
        public void ThisIsAnotherScenario()
        {
            "establish something"._(() => { });

            "when doing something"._(() => { });

            "it should be this"._(() => { });

            "it should not be that"._(() => { });
        }
    }
}
