﻿using System;
using System.IO;
using Newtonsoft.Json;
using Serilizer;
using JSystem.Perform;

namespace JSystem.Project
{
    public class ProjectManager
    {
        private readonly string _prosFile = AppDomain.CurrentDomain.BaseDirectory + "Project\\Pros.xml";

        [JsonIgnore]
        public Action<string> OnSavePointCloud;

        [JsonIgnore]
        public Action<string> OnLoadPointCloud;

        [JsonIgnore]
        public Action OnScanOnce;

        [JsonIgnore]
        public Func<string, bool> OnSaveProject;

        [JsonIgnore]
        public Func<string, bool> OnLoadProject;

        [JsonIgnore]
        public Action<string> OnSetUserRight;

        public Projects Projects;

        public string ProjectPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "Project\\" + Projects.CurrProject + ".json";
            }
        }

        public ProjectManager()
        {
            Projects = new Projects();
            if (!File.Exists(_prosFile))
                return;
            Projects = XMLSerilizer.Deserialize<Projects>(_prosFile);
            LoadProject(Projects.CurrProject);
        }

        ~ProjectManager()
        {
            XMLSerilizer.Serialize(Projects, _prosFile);
        }

        public void SetUserRight(string right)
        {
            OnSetUserRight?.Invoke(right);
        }

        public bool SaveProject(string projectName)
        {
            if (!Projects.ProjectsName.Contains(projectName))
                Projects.ProjectsName.Add(projectName);
            string fileDir = AppDomain.CurrentDomain.BaseDirectory + "Project\\";
            if (!Directory.Exists(fileDir))
                Directory.CreateDirectory(fileDir);
            Projects.CurrProject = projectName;
            if (!OnSaveProject(ProjectPath))
            {
                LogManager.Instance.AddLog($"产品{projectName}参数失败");
                return false;
            }
            XMLSerilizer.Serialize(Projects, _prosFile);
            LogManager.Instance.AddLog($"产品{projectName}参数已保存");
            return true;
        }

        public void LoadProject(string projectName = "")
        {
            projectName = projectName == "" ? Projects.CurrProject : projectName;
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Project\\" + projectName + ".json";
            if (!File.Exists(filePath))
                return;
            Projects.CurrProject = projectName;
            OnLoadProject?.Invoke(filePath);
            XMLSerilizer.Serialize(Projects, _prosFile);
            LogManager.Instance.AddLog($"当前产品切换为{projectName}");
        }

        public void DeleteProject(string projectName)
        {
            Projects.ProjectsName.Remove(Projects.CurrProject);
            Projects.CurrProject = "";
            string fileDir = AppDomain.CurrentDomain.BaseDirectory + "Project\\";
            File.Delete(fileDir + projectName + ".json");
        }
    }
}
