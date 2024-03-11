using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 删除字体，减少资源等优化功能，并且可以备份
/// </summary>
public class BackUpYouhuaWindow : EditorWindow
{
    [MenuItem("Assets/备份并删除")]
    public static void BackupAndDeleteFile()
    {
        if (EditorUtility.DisplayDialog("", "确认删除?还原功能没做", "Ok","Cancel"))
        {
            DoBackupAndDelete();
        }
    }
    static void DoBackupAndDelete()
    {

        if (Selection.count == 0) return;
        foreach (var obj in Selection.objects)
        {
            DoBackupAndDeleteOneByOne(obj);
        }
        AssetDatabase.Refresh();
    }

    static void DoBackupAndDeleteOneByOne(Object obj)
    {
        //注意i需要连.meta文件一起备份
        string path = AssetDatabase.GetAssetPath(obj);
        string destPath = Application.dataPath + "/../OutputBk/" + path;
        //TODO:检测文件是否存在
        var folder = Path.GetDirectoryName(destPath);

        string pathMeta = path + ".meta";
        
        string destMeta = Application.dataPath +  "/../OutputBk/" + pathMeta;
        if (Directory.Exists(folder) == false)
            Directory.CreateDirectory(folder);
        
        
        FileUtil.CopyFileOrDirectory(pathMeta,destMeta);
        FileUtil.CopyFileOrDirectory(path,destPath);
        FileUtil.DeleteFileOrDirectory(path);
        
    }

}
