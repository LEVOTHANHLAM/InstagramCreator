using InstagramCreator.ViotpApi;
using Newtonsoft.Json;
using Serilog;

namespace InstagramCreator.OtpServices.Codesim
{
    public class CodesimHttpHelper
    {
        public static async Task<CodesimResponse<CodesimResult>> BuyPhoneNumber(string key, string appId)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(CodesimConstant.CodesimApiUrl);
                string query = $"sim/get_sim?service_id={appId}&api_key={key}";//&network_id=1
                var response = await httpClient.GetAsync(query);
                var body = await response.Content.ReadAsStringAsync();
                try
                {
                    CodesimResponse<CodesimResult> data = JsonConvert.DeserializeObject<CodesimResponse<CodesimResult>>(body);
                    return data;
                }
                catch (Exception)
                {
                    CodesimResponse<string> data = JsonConvert.DeserializeObject<CodesimResponse<string>>(body);
                    CodesimResponse<CodesimResult> result = new CodesimResponse<CodesimResult>();
                    result.Message = data.Data.ToString();
                    result.Status = data.Status;
                    result.Timestamp = data.Timestamp;
                    return result;
                }
                
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                Log.Error($"{nameof(ViotpHttpHelper)}, params; {nameof(BuyPhoneNumber)},key; {key}, Error; {ex.Message}, Exception; {ex}");
                return null;
            }
        }
        public static async Task<CodesimResponse<CodesimResult>> GetOtp(string key, string id)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(CodesimConstant.CodesimApiUrl);
                string query = $"otp/get_otp_by_phone_api_key?otp_id={id}&api_key={key}";
                var response = await httpClient.GetAsync(query);
                var body = await response.Content.ReadAsStringAsync();
                try
                {
                    CodesimResponse<CodesimResult> data = JsonConvert.DeserializeObject<CodesimResponse<CodesimResult>>(body);
                    return data;
                }
                catch (Exception)
                {
                    CodesimResponse<string> data = JsonConvert.DeserializeObject<CodesimResponse<string>>(body);
                    CodesimResponse<CodesimResult> result = new CodesimResponse<CodesimResult>();
                    result.Message = data.Data.ToString();
                    result.Status = data.Status;
                    result.Timestamp = data.Timestamp;
                    return result;
                }
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                Log.Error($"{nameof(ViotpHttpHelper)}, params; {nameof(GetOtp)},key; {key}, Error; {ex.Message}, Exception; {ex}");
                return null;
            }
        }
    }
}
