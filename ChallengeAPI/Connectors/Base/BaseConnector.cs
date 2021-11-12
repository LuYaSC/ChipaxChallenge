using System.Threading.Tasks;

namespace ChallengeAPI.Connectors.Base
{
    public abstract class BaseConnector<RESPONSE>
       where RESPONSE : class, new()
    {
        public BaseConnector()
        {
            this.Response = new BaseResponse<RESPONSE>();
        }

        public BaseResponse<RESPONSE> Response { get; set; }

        private const string ERROR_OPEN_CONNECTION = "Error al abrir la conexión";

        public void Execute()
        {
            if (!this.Process())
            {
                this.Response = BaseResponse<RESPONSE>.SetOneError(ERROR_OPEN_CONNECTION);
            }
        }

        protected abstract bool Process();

    }
}
