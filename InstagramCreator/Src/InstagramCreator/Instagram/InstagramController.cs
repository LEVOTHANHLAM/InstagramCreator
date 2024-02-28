using AdvancedSharpAdbClient;
using LDPlayerAndADBController.AdbController;
using LDPlayerAndADBController;
using Serilog;
using InstagramCreator.Helper;
using System.Web.Services.Description;
using InstagramCreator.Models;
using LDPlayerAndADBController.ADBClient;

namespace InstagramCreator.Instagram
{
    public class InstagramController : IInstagramController
    {
        private string packageInstagram = "com.instagram.android";

        public int CheckLayoutInstagram(DeviceData data, AdbClient client)
        {
            try
            {
                int j = 0;
                while (j < 6)
                {
                    ADBClientController.StartApp(client, data, packageInstagram);
                    if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Create new account", "android.widget.Button", 120, true))
                    {
                        ADBClientController.FindElement(data, client, "text='ALLOW'", 10)?.Click();
                        return 1;
                    }
                    else if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Refresh", "android.widget.Button", 5))
                    {
                        return 2;
                    }
                    j++;
                    ADBClientController.StoptApp(client, data, packageInstagram);
                }

            }
            catch (Exception ex)
            {
                Log.Error($"End {nameof(InstagramController)}, params; {nameof(CheckLayoutInstagram)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
            }
            return 0;
        }
        public bool ImportFullnameInstagram(DeviceData data, AdbClient adbClient, string firtname, string lastname)
        {
            try
            {
                if (ADBClientController.ClearTextElement(data, adbClient, "class='android.widget.EditText'", 30))
                {
                    string fullname = $"{firtname} {lastname}";
                    ADBHelper.InputTextWithADBKeyboard(data.Serial, fullname);
                    if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Next", "android.widget.Button", 30, true))
                    {
                        if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Create a password", "android.view.View", 120, true))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(InstagramController)}, params; {nameof(ImportFullnameInstagram)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
                return false;
            }
        }
        public bool ImportPasswrodInstagram(DeviceData data, AdbClient adbClient, string password)
        {
            try
            {
                if (ADBClientController.InputElement(data, adbClient, "class='android.widget.EditText'", password))
                {
                    if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Next", "android.widget.Button", 30, true))
                    {
                        ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Save", "android.widget.Button", 30, true);

                        if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "android:id/alertTitle", "android.widget.TextView", 120, false))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(InstagramController)}, params; {nameof(ImportPasswrodInstagram)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
                return false;
            }
        }
        public bool SelecBirthDayInstagram(DeviceData data, AdbClient adbClient)
        {
            try
            {
                Random random = new Random();
                var select = random.Next(6, 12);
                for (int i = 0; i < select; i++)
                {
                    ADBHelper.SwipeByPercent(data.Serial, 26.2, 41.1, 26.8, 57.9);// thang
                    ADBHelper.SwipeByPercent(data.Serial, 48.5, 41.1, 48.5, 57.0);// ngay
                    ADBHelper.SwipeByPercent(data.Serial, 71.7, 41.1, 71.1, 56.7);// nam
                }
                if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "SET", "android.widget.Button", 30, true))
                {
                    if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Next", "android.widget.Button", 30, true))
                    {
                        if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Create a username", "android.view.View", 120, true))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(InstagramController)}, params; {nameof(SelecBirthDayInstagram)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
                return false;
            }
        }
        public bool ImportUsernameInstagram(DeviceData data, AdbClient adbClient, string username)
        {
            try
            {
                if (ADBClientController.InputElement(data, adbClient, "class='android.widget.EditText'", username, 30))
                {
                    ADBHelper.Delay(5, 7);
                    if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Next", "android.widget.Button", 30, true))
                    {
                        if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Sign up with email", "android.view.View", 30, false) || ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Sign up with mobile number", "android.view.View", 30, true))
                        {
                            return true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(InstagramController)}, params; {nameof(ImportUsernameInstagram)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
            }
            return false;
        }
        public bool ImportEmailOrPhoneInstagram(DeviceData data, AdbClient adbClient, string emailOrPhone)
        {
            try
            {
                if (ADBClientController.InputElement(data, adbClient, "class='android.widget.EditText'", emailOrPhone, 30))
                {
                    if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Next", "android.widget.Button", 30, true))
                    {
                        ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "CANCEL", "android.widget.Button", 15, true);
                        if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Enter the confirmation code", "android.view.View", 120, true))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(InstagramController)}, params; {nameof(ImportEmailOrPhoneInstagram)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
            }
            return false;
        }
        public bool ImportCodeInstagram(DeviceData data, AdbClient adbClient, string code)
        {
            try
            {
                if (ADBClientController.InputElement(data, adbClient, "class='android.widget.EditText'", code, 30))
                {
                    if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Next", "android.widget.Button", 30, true))
                    {
                        if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "I agree", "android.widget.Button", 60, true))
                        {
                            if (ADBClientController.FindElementIsExistOrClickByClass(data, adbClient, "Add a profile picture", "android.view.View", 120, false))
                            {
                                return true;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(InstagramController)}, params; {nameof(ImportCodeInstagram)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
            }
            return false;
        }
        public async Task<string> GetPasswordTowFAInstagramAsync(string index, DeviceData data, AdbClient client, string? urlProxy)
        {
            try
            {
                int i = 0;
                while (i < 6)
                {
                    LDController.KillApp("index", index, packageInstagram);
                    ADBHelper.Delay();
                    LDController.RunApp("index", index, packageInstagram);
                    if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "com.instagram.android:id/tab_avatar", "android.widget.ImageView", 30, true))
                    {
                        if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Options", "android.widget.Button", 30, true))
                        {
                            if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Settings and privacy", "android.widget.TextView", 30, true))
                            {
                                if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Accounts Center", "android.view.View", 10, true))
                                {
                                    ADBHelper.Delay(8, 12);
                                    ADBHelper.SwipeByPercent(data.Serial, 48.2, 87.5, 47.6, 35.0, 500);
                                    Thread.Sleep(500);
                                    if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Password and security", "android.view.View", 30, true))
                                    {
                                        if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Two-factor authentication", "android.view.View", 30, true))
                                        {
                                            if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Instagram", "android.view.View", 30, true))
                                            {
                                                if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Add extra security to your account", "android.view.View", 30))
                                                {
                                                    if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Next", "android.widget.Button", 30, true))
                                                    {
                                                        ADBHelper.Delay(8, 12);
                                                        var findElements = client.FindElements(data, "//node[@class='android.view.View']", TimeSpan.FromSeconds(3));
                                                        if (findElements != null)
                                                        {
                                                            foreach (var element in findElements)
                                                            {
                                                                var towFA = element.Attributes.GetValueOrDefault("text");
                                                                if (towFA.Replace(" ", "").Length == 32)
                                                                {
                                                                    if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Next", "android.widget.Button", 30, true))
                                                                    {
                                                                        if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Enter code", "android.view.View", 30))
                                                                        {
                                                                            var code = await InstagramHelper.GetFacebookLoginCode2FA(towFA.Replace(" ", ""), urlProxy);
                                                                            if (!string.IsNullOrEmpty(code))
                                                                            {
                                                                                Thread.Sleep(500);
                                                                                ADBHelper.TapByPercent(data.Serial, 11.8, 40.4);
                                                                                Thread.Sleep(500);
                                                                                ADBHelper.InputText(data.Serial, code);
                                                                                Thread.Sleep(500);
                                                                                if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Next", "android.widget.Button", 30, true))
                                                                                {
                                                                                    if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Two-factor authentication is on", "android.view.View", 30))
                                                                                    {
                                                                                        if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Done", "android.widget.Button", 30, true))
                                                                                        {
                                                                                            return towFA;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    i++;
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(InstagramController)}, params; {nameof(GetPasswordTowFAInstagramAsync)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
                return null;
            }

        }
        public bool UploadAvatarInstagram(string index, DeviceData data, AdbClient client, string fileImage)
        {
            try
            {
                ADBHelper.ADB(data.Serial, "shell am broadcast -a android.intent.action.MEDIA_SCANNER_SCAN_FILE -d file:///sdcard/Pictures/");
                ADBHelper.DeletePNGFilesAndScanMedia(data.Serial, "/storage/emulated/0");
                int i = 0;
                while (i < 6)
                {
                    i++;
                    LDController.KillApp("index", index, "com.instagram.android");
                    ADBHelper.Delay();
                    // Lấy tên tệp tin
                    string fileName = Path.GetFileName(fileImage);
                    // Tạo đường dẫn đến tệp tin đích
                    string destinationFilePath = Path.Combine(Path.Combine(Environment.CurrentDirectory, $"LDPlayer\\{index}"), fileName);
                    File.Copy(fileImage, destinationFilePath, true);
                    ADBHelper.Delay(1);
                    LDController.RunApp("index", index, "com.android.gallery3d");
                    ADBHelper.Delay(1);
                    LDController.RunApp("index", index, "com.instagram.android");
                    if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "com.instagram.android:id/tab_avatar", "android.widget.ImageView", 15, true))
                    {
                        if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Edit profile", "android.widget.Button", 30, true))
                        {
                            if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "com.instagram.android:id/profile_pic_imageview", "android.widget.ImageView", 30, true))
                            {
                                if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "New profile picture", "android.view.ViewGroup", 15, true))
                                {
                                    ADBClientController.FindElementIsExistOrClickByClass(data, client, "ALLOW", "android.widget.Button", 30, true);
                                    ADBHelper.TapByPercent(data.Serial, 91.5, 6.7);
                                    ADBHelper.Delay(8, 12);
                                    ADBHelper.TapByPercent(data.Serial, 91.5, 6.7);
                                    ADBHelper.Delay(8, 12);
                                    ADBHelper.TapByPercent(data.Serial, 91.5, 6.7);
                                    ADBHelper.Delay(5, 6);
                                    ADBHelper.TapByPercent(data.Serial, 91.5, 6.7);
                                    ADBHelper.Delay(10, 15);
                                    if (File.Exists(Path.Combine(Environment.CurrentDirectory, $"LDPlayer\\{index}\\{Path.GetFileName(fileImage)}")))
                                    {
                                        File.Delete(Path.Combine(Environment.CurrentDirectory, $"LDPlayer\\{index}\\{Path.GetFileName(fileImage)}"));
                                    }
                                    return true;
                                }
                            }
                        }
                    }
                    if (File.Exists(Path.Combine(Environment.CurrentDirectory, $"LDPlayer\\{index}\\{Path.GetFileName(fileImage)}")))
                    {
                        File.Delete(Path.Combine(Environment.CurrentDirectory, $"LDPlayer\\{index}\\{Path.GetFileName(fileImage)}"));
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($" {nameof(InstagramController)}, params; {nameof(UploadAvatarInstagram)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
                return false;
            }
        }
        public bool ChangeEmail(string index, DeviceData data, AdbClient client, string email)
        {
            try
            {
                int i = 0;
                while (i < 6)
                {
                    i++;
                    LDController.KillApp("index", index, packageInstagram);
                    ADBHelper.Delay();
                    LDController.RunApp("index", index, packageInstagram);
                    if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "com.instagram.android:id/tab_avatar", "android.widget.ImageView", 30, true))
                    {
                        if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Options", "android.widget.Button", 30, true))
                        {
                            if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Settings and privacy", "android.widget.TextView", 30, true))
                            {
                                if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Accounts Center", "android.view.View", 30, true))
                                {
                                    ADBHelper.Delay(5, 8);
                                    ADBHelper.SwipeByPercent(data.Serial, 48.2, 87.5, 47.6, 35.0, 500);
                                    ADBHelper.Delay(3, 5);
                                    if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Personal details", "android.view.View", 30, true))
                                    {
                                        if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Contact Info", "android.view.View", 30, true))
                                        {
                                            if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Add new contact", "android.view.View", 30, true))
                                            {
                                                if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Add email", "android.view.View", 30, true))
                                                {
                                                    if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Enter email address", "android.view.View", 30, true))
                                                    {
                                                        Thread.Sleep(500);
                                                        ADBHelper.InputTextWithADBKeyboard(data.Serial, email);
                                                        Thread.Sleep(500);
                                                        ADBClientController.ClickElement(data, client, "class='android.widget.CompoundButton'", 10);
                                                        if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Next", "android.view.View", 30, true))
                                                        {
                                                            if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Enter your confirmation code", "android.view.View", 30))
                                                            {
                                                                return true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    i++;
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($" {nameof(InstagramController)}, params; {nameof(ChangeEmail)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
                return false;
            }

        }
        public bool ImportCodeChangeEmail(string index, DeviceData data, AdbClient client, string code)
        {
            try
            {
                if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Enter your confirmation code", "android.view.View", 30))
                {
                    ADBClientController.ClickElement(data, client, "class='android.widget.EditText'", 30);
                    Thread.Sleep(500);
                    ADBHelper.InputText(data.Serial, code);
                    Thread.Sleep(500);
                    if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Next", "android.view.View", 30, true))
                    {
                        if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "Close", "android.view.View", 30, true))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(InstagramController)}, params; {nameof(ImportCodeChangeEmail)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
                return false;
            }

        }
        public bool CreatPostInstagram(string index, DeviceData data, AdbClient client, string fileImage)
        {
            try
            {
                LDController.KillApp("index", index, "com.instagram.android");
                ADBHelper.Delay(1);
                // Lấy tên tệp tin
                string fileName = Path.GetFileName(fileImage);
                // Tạo đường dẫn đến tệp tin đích
                string destinationFilePath = Path.Combine(Path.Combine(Environment.CurrentDirectory, $"LDPlayer\\{index}"), fileName);
                File.Copy(fileImage, destinationFilePath, true);
                ADBHelper.Delay(1);
                LDController.RunApp("index", index, "com.android.gallery3d");
                ADBHelper.Delay(1);
                LDController.RunApp("index", index, "com.instagram.android");
                if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "com.instagram.android:id/creation_tab", "android.widget.FrameLayout", 15, true))
                {
                    if (ADBClientController.FindElement(data, client, "text='ALLOW'", 30) != null)
                    {
                        ADBClientController.ClickElement(data, client, "text='ALLOW'", 30);
                        ADBHelper.Delay(1, 3);
                        ADBClientController.ClickElement(data, client, "text='ALLOW'", 30);
                        ADBHelper.Delay(1, 3);
                        ADBClientController.ClickElement(data, client, "text='ALLOW'", 30);
                    }
                    if (ADBClientController.FindElement(data, client, "resource-id='com.instagram.android:id/new_post_title'", 30) != null)
                    {
                        ADBHelper.TapByPercent(data.Serial, 91.5, 6.7);
                        ADBHelper.Delay(5, 8);
                        ADBHelper.TapByPercent(data.Serial, 91.5, 6.7);
                        if (ADBClientController.FindElementIsExistOrClickByClass(data, client, "com.instagram.android:id/bb_primary_action_container", "android.widget.Button", 30, true))
                        {
                            ADBHelper.Delay(5, 8);
                        }
                        ADBHelper.Delay(5, 8);
                        ADBHelper.TapByPercent(data.Serial, 91.5, 6.7);
                        ADBHelper.Delay(5, 8);
                        if (File.Exists(Path.Combine(Environment.CurrentDirectory, $"LDPlayer\\{index}\\{Path.GetFileName(fileImage)}")))
                        {
                            File.Delete(Path.Combine(Environment.CurrentDirectory, $"LDPlayer\\{index}\\{Path.GetFileName(fileImage)}"));
                        }
                        return true;
                    }

                }
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, $"LDPlayer\\{index}\\{Path.GetFileName(fileImage)}")))
                {
                    File.Delete(Path.Combine(Environment.CurrentDirectory, $"LDPlayer\\{index}\\{Path.GetFileName(fileImage)}"));
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(InstagramController)}, params; {nameof(CreatPostInstagram)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
                LDController.ADB("index", index, $"shell rm /sdcard/Pictures/{Path.GetFileName(fileImage)}");
                return false;
            }

        }
        public bool FollowSuggestedInstagram(string index, DeviceData data, AdbClient client, int countFollow)
        {
            try
            {
                LDController.KillApp("index", index, packageInstagram);
                ADBHelper.Delay();
                LDController.RunApp("index", index, packageInstagram);
                ADBClientController.ClickElement(data, client, "resource-id='com.instagram.android:id/tab_avatar'", 15);
                if (ADBClientController.FindElement(data, client, "resource-id='com.instagram.android:id/netego_carousel_cta'", 10) != null && countFollow > 0)
                {
                    ADBClientController.ClickElement(data, client, "resource-id='com.instagram.android:id/netego_carousel_cta'", 15);
                    if (ADBClientController.FindElement(data, client, "text='Allow Instagram to access your contacts?'", 15) != null)
                    {
                        ADBClientController.ClickElement(data, client, "resource-id='com.instagram.android:id/negative_button_row'", 15);
                    }
                    if (ADBClientController.FindElement(data, client, "resource-id='com.instagram.android:id/recommended_user_card_follow_button'", 10) != null)
                    {
                        while (countFollow > 0)
                        {
                            var list_elements = ADBClientController.FindElements(data, client, "resource-id='com.instagram.android:id/recommended_user_card_follow_button'", 10);
                            if (list_elements != null && list_elements.Any())
                            {
                                foreach (var element in list_elements)
                                {
                                    if (element.Attributes.Values.Contains("Follow"))
                                    {
                                        element.Click();
                                        countFollow--;
                                    }
                                }
                                ADBHelper.SwipeByPercent(data.Serial, 49.1, 91.9, 47.3, 36.5, 700);
                                ADBHelper.Delay(2, 5);
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(InstagramController)}, params; {nameof(FollowSuggestedInstagram)},deviceId; {data.Serial}, Error; {ex.Message}, Exception; {ex}");
                return false;
            }

        }
    }
}
