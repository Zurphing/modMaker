using System;
using System.IO;
namespace modMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("mod", "*.*", SearchOption.AllDirectories);
            var files_pc = Directory.GetFiles("mod_pc", "*.*", SearchOption.AllDirectories);
            var files_ps2 = Directory.GetFiles("mod_ps2", "*.*", SearchOption.AllDirectories);
            var output = "assets:\r";
            var output2 = "assets:\r";
            var output3 = "assets:\r";
            foreach (var file in files)
            {
                output += String.Format("- name: {0}\r  method: copy\r  source:\r  - name: {0}\r", file.Remove(0,4)); //old version; no platform specificity.
            }
            File.WriteAllText("mod/OUTPUTmod.yml", output);
            foreach (var file in files_pc)
            {
                output2 += String.Format("- name: {0}\r  platform: pc\r  method: copy\r  source:\r  - name: {0}\r", file.Remove(0, 7)); //platform: pc
            }
            File.WriteAllText("mod_pc/OUTPUTmod_PC.yml", output2);
            foreach (var file in files_ps2)
            {
                output3 += String.Format("- name: {0}\r  platform: ps2\r  method: copy\r  source:\r  - name: {0}\r", file.Remove(0, 8)); //platform: ps2
            }
            File.WriteAllText("mod_ps2/OUTPUTmod_PS2.yml", output3);
            }
    }
}
