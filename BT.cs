using System;

public class Class1
{
    partial class MyResourceDictionary : ResourceDictionary
    {
        public partial class ButtonDictionary
        {
            private void ButtonClick(object sender, RoutedEventArgs e)
            {
                new SoundPlayer(@"C:\Users\Artur\source\repos\BestRadioStation\Mouse Click - Sound Effect (HD).mp3").Play();
            }

        }
    }
}
