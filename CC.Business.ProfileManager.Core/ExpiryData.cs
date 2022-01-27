using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Business.ProfileManager.Core.CribisComX {
    public struct ExpiryData {
        public TimeSpan Interval;
        public bool Renewable;

        public ExpiryData(TimeSpan interval, bool renewable) {
            this.Interval = interval;
            this.Renewable = renewable;
        }
    }
}
