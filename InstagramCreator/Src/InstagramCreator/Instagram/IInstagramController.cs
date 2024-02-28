using AdvancedSharpAdbClient;

namespace InstagramCreator.Instagram
{
    public interface IInstagramController
    {
        int CheckLayoutInstagram(DeviceData data, AdbClient client);
        bool ImportFullnameInstagram(DeviceData data, AdbClient adbClient, string firtname, string lastname);
        bool ImportPasswrodInstagram(DeviceData data, AdbClient adbClient, string password);
        bool SelecBirthDayInstagram(DeviceData data, AdbClient adbClient);
        bool ImportUsernameInstagram(DeviceData data, AdbClient adbClient, string username);
        bool ImportEmailOrPhoneInstagram(DeviceData data, AdbClient adbClient, string emailOrPhone);
        bool ImportCodeInstagram(DeviceData data, AdbClient adbClient, string code);
        Task<string> GetPasswordTowFAInstagramAsync(string index, DeviceData data, AdbClient client, string? urlProxy);
        bool UploadAvatarInstagram(string index, DeviceData data, AdbClient client, string fileImage);
        bool ChangeEmail(string index, DeviceData data, AdbClient client, string email);
        bool ImportCodeChangeEmail(string index, DeviceData data, AdbClient client, string code);
        bool CreatPostInstagram(string index, DeviceData data, AdbClient client, string fileImage);
        bool FollowSuggestedInstagram(string index, DeviceData data, AdbClient client, int countFollow);
    }
}
