using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace CC.Business.ProfileManager.Core.CribisComX {
    public delegate void ExpriredProfileEventHandler(ProfileKey key);

    public class ProfileTimer : IDisposable {
        private Timer timer;
        private ProfileKey key;
        private bool isRenewable;

        public event ExpriredProfileEventHandler Expired;

        public ProfileTimer(ProfileKey key, ExpiryData expiry) {
            this.key = key;
            if (expiry.Interval.TotalMilliseconds > 0 && expiry.Interval.TotalMilliseconds < Int32.MaxValue) {
                this.timer = new Timer(expiry.Interval.TotalMilliseconds);
                this.timer.AutoReset = false;
                this.isRenewable = expiry.Renewable;
                this.timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            }
        }

        ~ProfileTimer() {
            CleanUp();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e) {
            if (null != Expired)
                Expired(this.key);
        }

        private void CleanUp() {
            if (null != this.timer)
                this.timer.Dispose();
        }

        #region IDisposable Members

        public void Dispose() {
            CleanUp();
            GC.SuppressFinalize(this);
        }

        #endregion

        public void Renew() {
            if (isRenewable && null != this.timer) {
                this.timer.Stop();
                this.timer.Start();
            }
        }

        public void Start() {
            if (null != this.timer) {
                this.timer.Start();
            }
        }
    }
}
