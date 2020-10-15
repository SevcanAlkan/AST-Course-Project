using MovieStore.Core.Validation;
using MovieStore.Data.Service;
using MovieStore.Data.ViewModel;
using MovieStore.Desktop.Helper;
using MovieStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Desktop.ViewModel
{
    public class MovieDetailViewModel
    {
        private IMovieService _service;
        private ILanguageService _languageService;
        private IPublisherService _publisherService;

        public MovieDetailViewModel(
            IMovieService service,
            ILanguageService languageService,
            IPublisherService publisherService)
        {
            this._service = service;
            this._languageService = languageService;
            this._publisherService = publisherService;
        }

        public Guid Id { get; set; }

        public Movie Rec { get; set; }

        public void LoadRec(Guid id)
        {
            this.Id = id;
            Rec = new Movie();

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
            Rec = new Movie();
        }

        #region CRUD

        public async Task<Movie> Add()
        {
            return await _service.Add(Rec, UserInfo.UserId);
        }

        public async Task<Movie> Update()
        {
            return await _service.Update(Id, Rec, UserInfo.UserId);
        }

        #endregion

        #region GET METHODS

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
            if (searchKey == "")
                return _languageService.GetAll(a => a.IsDeleted == false).ToList();
            else
                return _languageService.GetAll(a => a.IsDeleted == false && (a.Code.Contains(searchKey)
                || a.Name.Contains(searchKey)
                || a.NativeName.Contains(searchKey))).ToList();
        }

        public string GetPublisherName(Guid id)
        {
            var publisherRec = _publisherService.GetById(id);

            return publisherRec != null ? publisherRec.Name : "";
        }

        public List<SelectListVM<Guid>> GetPublisherList()
        {
            return _publisherService.GetSelectList();
        }

        #endregion
    }
}
