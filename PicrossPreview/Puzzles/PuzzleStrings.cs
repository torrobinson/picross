using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicrossPreview.Puzzles
{
    public static class PuzzleStrings
    {
        public static char TrueCharacter = '#';
        public static string Cherries =>
            "____######" + Environment.NewLine +
            "_______#__" + Environment.NewLine +
            "______##__" + Environment.NewLine +
            "____##_#__" + Environment.NewLine +
            "_###___#__" + Environment.NewLine +
            "#_###_###_" + Environment.NewLine +
            "######_###" + Environment.NewLine +
            "##########" + Environment.NewLine +
            "####_#####" + Environment.NewLine +
            "______###_";

        public static string TenBlank => (
            "_____ _____" + Environment.NewLine +
            "_____ _____" + Environment.NewLine +
            "_____ _____" + Environment.NewLine +
            "_____ _____" + Environment.NewLine +
            "_____ _____" + Environment.NewLine +
            "_____ _____" + Environment.NewLine +
            "_____ _____" + Environment.NewLine +
            "_____ _____" + Environment.NewLine +
            "_____ _____" + Environment.NewLine +
            "_____ _____").Replace(" ", String.Empty);

        public static string Sword =>
         (
            "_____ _##__ _____" + Environment.NewLine +
            "_____ #_##_ _____" + Environment.NewLine +
            "_____ ####_ _____" + Environment.NewLine +
            "_____ _##__ _____" + Environment.NewLine +
            "_____ _##__ _____" + Environment.NewLine +
            "____# ___## _____" + Environment.NewLine +
            "___#_ ####_ #____" + Environment.NewLine +
            "___## ##### #____" + Environment.NewLine +
            "_____ #_##_ _____" + Environment.NewLine +
            "_____ #_##_ _____" + Environment.NewLine +
            "_____ #_##_ _____" + Environment.NewLine +
            "_____ #_##_ _____" + Environment.NewLine +
            "_____ #_##_ _____" + Environment.NewLine +
            "_#### ##### ####_" + Environment.NewLine +
            "##___ ____ #####").Replace(" ", String.Empty);

        public static string FifteenBlank =>
        (
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____" + Environment.NewLine +
            "_____ _____ _____").Replace(" ", String.Empty);

        public static string Difficult =>
            "_____#####" + Environment.NewLine +
            "___##_####" + Environment.NewLine +
            "__#____###" + Environment.NewLine +
            "_###_#####" + Environment.NewLine +
            "#######_##" + Environment.NewLine +
            "#____#####" + Environment.NewLine +
            "#_______##" + Environment.NewLine +
            "_#_#_#_#__" + Environment.NewLine +
            "__#####___" + Environment.NewLine +
            "___#______";
    }
}
