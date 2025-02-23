﻿using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.input;

namespace Api_budger.Services.Abstractions
{
    public interface IBudgerService
    {
        #region income
        /// <summary>
        /// Получает список доходов по Id семьи
        /// </summary>
        /// <param name="familyId">Id семьи</param>
        /// <returns>Список доходов</returns>
        public Task<IEnumerable<Incom>> GetIncomByFamilyIdAsyns();
        /// <summary>
        /// Получает список доходов по Id пользователя
        /// </summary>
        /// <param name="useryId">Id пользователя</param>
        /// <returns>Список доходов</returns>
        public Task<IEnumerable<Incom>> GetIncomByUserIdAsyns();
        /// <summary>
        /// Добавляет доход 
        /// </summary>
        /// <param name="inputIncom">входные даннык</param>
        /// <returns>Новый доход</returns>
        public Task<IEnumerable<Incom>> AddIncomsAsyns(IEnumerable<InputIncom> inputIncom);
        /// <summary>
        /// Удаляет доход по Id
        /// </summary>
        /// <param name="incomId">Id дохода</param>
        /// <returns>Флаг успешности</returns>
        public Task<bool> DeleteIncomByIdAsyns(long incomId);
        /// <summary>
        /// Изменяет доход по Id и новым данным
        /// </summary>
        /// <param name="Id">Id дохода</param>
        /// <param name="inputIncom">Входные данные</param>
        /// <returns>Измененный доход</returns>
        public Task<Incom> CorrectIncomAsyns(long Id, InputIncom inputIncom);

        #endregion

        #region incomeCategory
        /// <summary>
        /// Подучает категории доходов по Id семьи
        /// </summary>
        /// <param name="familyId">Id семьи</param>
        /// <returns>Список категорий</returns>
        public Task<IEnumerable<IncomCategory>> GetIncomCategoryByFamilyIdAsyns();
        /// <summary>
        /// Добавляет категорию в семью
        /// </summary>
        /// <param name="inputIncomCategory">Данные категории доходов</param>
        /// <returns>Новая категория доходов</returns>
        public Task<IEnumerable<IncomCategory>> AddIncomCategoryInFamilyAsyns(IEnumerable<InputIncomCategory> inputIncomCategory);
        /// <summary>
        /// Удаляет категорию из семьи по Id
        /// </summary>
        /// <param name="incomCategoryId">Id категории доходов</param>
        /// <returns>Флаг успешности</returns>
        public Task<bool> DeleteIncomCategoryFromFamilyByIdAsyns(long incomCategoryId);
        /// <summary>
        /// Изменяет категорию доходов в семье по id пользователя
        /// </summary>
        /// <param name="Id">Id категории доходов</param>
        /// <param name="inputIncomCategory">Новые данные</param>
        /// <returns>Измененная категория доходов</returns>
        public Task<IncomCategory> CorrectIncomCategoryFromUserByIdAsyns(long Id, InputIncomCategory inputIncomCategory);
        #endregion

        #region budger
        /// <summary>
        /// Получает расходы по Id семьи
        /// </summary>
        /// <param name="familyId">Id семьи</param>
        /// <returns>Список раходов</returns>
        public Task<IEnumerable<Budger>> GetBudgerByFamilyIdAsyns();
        /// <summary>
        /// Получает расходы по Id пользователя
        /// </summary>
        /// <returns>Список расходов</returns>
        public Task<IEnumerable<Budger>> GetBudgerByUserIdAsyns();
        /// <summary>
        /// Добавляет расходы
        /// </summary>
        /// <param name="inputBudger">входные данные</param>
        /// <returns>Новый расход</returns>
        public Task<IEnumerable<Budger>> AddBudgersAsyns(IEnumerable<InputBudger> inputBudger);
        /// <summary>
        /// Удаляет расход по Id
        /// </summary>
        /// <param name="budgerId">Id расходов</param>
        /// <returns>Флаг успешности</returns>
        public Task<bool> DeleteBudgerByIdAsyns(long budgerId);
        /// <summary>
        /// Изменяет расход
        /// </summary>
        /// <param name="Id">Id расхода</param>
        /// <param name="inputBudger">Новые параметры</param>
        /// <returns>Измененный расход</returns>
        public Task<Budger> CorrectBudgerAsyns(long Id, InputBudger inputBudger);
        #endregion

        #region budgerCategory
        /// <summary>
        /// Получает категории росходов по Id семьи
        /// </summary>
        /// <param name="familyId">Id семьи</param>
        /// <returns>Список категорий</returns>
        public Task<IEnumerable<BudgerCategory>> GetBudgerCategoryByFamilyIdAsyns();
        /// <summary>
        /// Добавляет категорию в семью
        /// </summary>
        /// <param name="inputBudger">Входные данные</param>
        /// <returns>Новая категория расходов</returns>
        public Task<IEnumerable<BudgerCategory>> AddBudgerCategoryInFamilyAsyns(IEnumerable<InputBudgerCategory> inputBudger);
        /// <summary>
        /// Удаляет категорию расходов из семьи
        /// </summary>
        /// <param name="BudgerCategoryId">Id категории расходов</param>
        /// <param name="familyId">Id семьи</param>
        /// <returns>Флаг успешности</returns>
        public Task<bool> DeleteBudgerCategoryFromFamilyByIdAsyns(long budgerCategoryId);
        /// <summary>
        /// Изменяет категорию доходов в семье по id пользователя
        /// </summary>
        /// <param name="id">Id категории доходов</param>
        /// <param name="inputBudgerCategory">Новые данные</param>
        /// <returns>Измененная категория доходов</returns>
        public Task<BudgerCategory> CorrectBudgerCategoryFromUserByIdAsyns(long id, InputBudgerCategory inputBudgerCategory);
        #endregion

        #region defaultCategory
        /// <summary>
        /// получает все дефолтные категории доходов
        /// </summary>
        /// <returns>лист категорий доходов</returns>
        public Task<IEnumerable<DefaultIncomeCategory>> GetDefaultIncomCategory();
        /// <summary>
        /// получает все дефолтные категории расходов
        /// </summary>
        /// <returns>лист категорий расходов</returns>
        public Task<IEnumerable<DefaultBudgerCategory>> GetDefaultBudgerCategory();
        /// <summary>
        /// добавляет список дефолтных категорий доходов
        /// </summary>
        /// <param name="incomCategory">список категорий</param>
        public Task AddDefaultIncomCategory(IEnumerable<DefaultIncomeCategory> incomCategory);
        /// <summary>
        /// добавляет список дефолтных категорий расходов
        /// </summary>
        /// <param name="budgerCategory">список категорий</param>
        public Task AddDefaultBudgerCategory(IEnumerable<DefaultBudgerCategory> budgerCategory);
        /// <summary>
        /// удаляет категорию доходов из дефолтных
        /// </summary>
        /// <param name="id">id категории</param>
        /// <returns>флаг успешности</returns>
        public Task<bool> DeleteDefaultIncomCategoryAsyns(long id);
        /// <summary>
        /// удаляет категорию расходов из дефолтных
        /// </summary>
        /// <param name="id">id категории</param>
        /// <returns>флаг успешности</returns>
        public Task<bool> DeleteDefaultBudgerCategory(long id);
        #endregion
    }
}
