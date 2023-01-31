using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Setup.Scripts.Editor {
    internal static class SetupActions {
        public static void SetProjectName(string projectName) {
            string displayName = projectName;
            
            string projectDirectoryName = projectName.Replace(" ", "_");
            RenameProjectFolder(projectDirectoryName);

            string assemblyProjectName = StringHelper.ToPascalCase(projectName);
            RenameAssembly(assemblyProjectName);

        }

        private static void RenameAssembly(string assemblyProjectName) {
            string[] potentialAssemblyDefs = AssetDatabase.FindAssets(MagicStrings.ProjectNamePlaceholder);
            AssemblyDefinitionAsset? assemblyDefinitionAsset = null;
            string? assemblyDefinitionAssetPath = null;
            foreach (string path in potentialAssemblyDefs) {
                Object loadedAsset = AssetDatabase.LoadAssetAtPath<Object>(path);
                
                if (loadedAsset is not AssemblyDefinitionAsset definitionAsset) continue;

                assemblyDefinitionAsset = definitionAsset;
                assemblyDefinitionAssetPath = path;
            }

            if (assemblyDefinitionAsset == null) Debug.LogError("Could not find AssemblyDefinitionAsset named " 
                                                                + MagicStrings.ProjectNamePlaceholder);
            
            AssetDatabase.MoveAsset(assemblyDefinitionAssetPath, MagicStrings.RelativeAssetDatabaseFolder + assemblyProjectName);
        }

        private static void RenameProjectFolder(string replacementName) {
            string projectFolder = MagicStrings.RelativeAssetDatabaseFolder + MagicStrings.ProjectNamePlaceholder;
            if (!AssetDatabase.IsValidFolder(projectFolder)) {
                Debug.LogError("Could not find directory: " + projectFolder);
            }

            string renamedPath = MagicStrings.RelativeAssetDatabaseFolder + replacementName;
            AssetDatabase.MoveAsset(projectFolder, renamedPath);
        }
    }
}