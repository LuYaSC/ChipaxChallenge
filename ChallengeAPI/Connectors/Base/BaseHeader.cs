using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeAPI.Connectors.Base
{
    public class BaseHeader
    {
        public BaseHeader()
        {
            this.isOk = true;
        }

        private bool isOk;

        private List<string> error;

        private Exception e;

        public bool IsOk
        {
            get
            {
                return this.isOk;
            }
        }

        public List<string> Error
        {
            get
            {
                return this.error;
            }
        }

        public string FirstError
        {
            get
            {
                return this.error == null ? null : this.error.FirstOrDefault();
            }
        }

        public Exception Exception
        {
            get
            {
                return e;
            }
        }

        public void SetOk()
        {
            this.isOk = true;
            this.error = null;
        }

        public void SetError(List<string> error)
        {
            this.isOk = false;
            this.error = error;
        }

        public void SetException(Exception e)
        {
            this.isOk = false;
            this.e = e;
        }
    }
}
