using MovieStore.Core.Validation;
using MovieStore.Data.Service;
using MovieStore.Data.ViewModel;
using MovieStore.Desktop.Helper;
using MovieStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Desktop.ViewModel
{
    public class ProjectDetailViewModel
    {
        private IProjectService _service;
        private IMovieService _movieService;
        private IProjectCastService _castService;
        private ILanguageService _languageService;

        public ProjectDetailViewModel(IProjectService service, IMovieService moviewService, IProjectCastService castService, ILanguageService languageService)
        {
            this._service = service;
            this._movieService = moviewService;
            this._castService = castService;
            this._languageService = languageService;
        }

        public Guid Id { get; set; }

        public Project Rec { get; set; }

        public void LoadRec(Guid id)
        {
            this.Id = id;
            Rec = new Project();

            if (Id != null && !Id.IsNotValid())
            {
                var dto = _service.GetById(Id);

                if (dto != null)
                {
                    Rec = dto;
                }
            }
        }

        public void Clean()
        {
            Id = Guid.Empty;
            Rec = new Project();
        }

        #region CRUD

        public async Task<Project> Add()
        {
            return await _service.Add(Rec, UserInfo.UserId);
        }

        public async Task<Project> Update()
        {
            return await _service.Update(Id, Rec, UserInfo.UserId);
        }

        #endregion

        #region GET METHODS
        public List<SelectListGuidVM> GetMovieList()
        {
            return _movieService.GetSelectList();
        }

        public string GetMovieName(Guid id)
        {
            return _movieService.GetById(id).Name;
        }

        public List<ProjectCastVM> GetCastList()
        {
            return _castService.GetList(this.Id);
        }

        public string GetLanguageName(Guid id)
        {
            var languageRec = _languageService.GetById(id);

            return languageRec != null ? languageRec.Code + " - " + languageRec.Name : "";
        }

        public Language GetLanguage(Guid id)
        {
            return _languageService.GetById(id);
        }

        public List<Language> GetLanguageList(string searchKey = "")
        {
            if(searchKey == "")
                return _languageService.GetAll(a => a.IsDeleted == false).ToList();
            else
                return _languageService.GetAll(a => a.IsDeleted == false && (a.Code.Contains(searchKey) 
                || a.Name.Contains(searchKey) 
                || a.NativeName.Contains(searchKey))).ToList();
        }

        #endregion
    }
}
