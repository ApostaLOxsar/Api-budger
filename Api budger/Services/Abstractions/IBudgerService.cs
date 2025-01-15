using Api_budger.Models.budgers;
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
        public Task<IEnumerable<Incom>> GetIncomByFamilyIdAsyns(long familyId);
        /// <summary>
        /// Получает список доходов по Id пользователя
        /// </summary>
        /// <param name="useryId">Id пользователя</param>
        /// <returns>Список доходов</returns>
        public Task<IEnumerable<Incom>> GetIncomByUserIdAsyns(long useryId);
        /// <summary>
        /// Добавляет доход 
        /// </summary>
        /// <param name="inputIncom">входные даннык</param>
        /// <returns>Новый доход</returns>
        public Task<Incom> AddIncomAsyns(InputIncom inputIncom);
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
        public Task<IEnumerable<IncomCategory>> GetIncomCategoryByFamilyIdAsyns(long familyId);
        /// <summary>
        /// Добавляет категорию в семью
        /// </summary>
        /// <param name="inputIncomCategory">Данные категории доходов</param>
        /// <returns>Новая категория доходов</returns>
        public Task<IncomCategory> AddIncomCategoryInFamilyAsyns(InputIncomCategory inputIncomCategory);
        /// <summary>
        /// Удаляет категорию из семьи по Id
        /// </summary>
        /// <param name="incomCategoryId">Id категории доходов</param>
        /// <param name="familyId">Id семьи</param>
        /// <returns>Флаг успешности</returns>
        public Task<bool> DeleteIncomCategoryFromFamilyByIdAsyns(long incomCategoryId, long familyId);
        /// <summary>
        /// Изменяет категорию доходов в семье по id пользователя
        /// </summary>
        /// <param name="Id">Id категории доходов</param>
        /// <param name="UserId">Id пользователя</param>
        /// <param name="inputIncomCategory">Новые данные</param>
        /// <returns>Измененная категория доходов</returns>
        public Task<IncomCategory> CorrectIncomCategoryFromUserByIdAsyns(long Id, long userId, InputIncomCategory inputIncomCategory);
        #endregion

        #region budger
        /// <summary>
        /// Получает расходы по Id семьи
        /// </summary>
        /// <param name="familyId">Id семьи</param>
        /// <returns>Список раходов</returns>
        public Task<IEnumerable<Budger>> GetBudgerByFamilyIdAsyns(long familyId);
        /// <summary>
        /// Получает расходы по Id пользователя
        /// </summary>
        /// <param name="useryId">Id пользователя</param>
        /// <returns>Список расходов</returns>
        public Task<IEnumerable<Budger>> GetBudgerByUserIdAsyns(long useryId);
        /// <summary>
        /// Добавляет расходы
        /// </summary>
        /// <param name="inputBudger">входные данные</param>
        /// <returns>Новый расход</returns>
        public Task<Budger> AddBudgerAsyns(InputBudger inputBudger);
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
        public Task<IEnumerable<BudgerCategory>> GetBudgerCategoryByFamilyIdAsyns(long familyId);
        /// <summary>
        /// Добавляет категорию в семью
        /// </summary>
        /// <param name="inputBudger">Входные данные</param>
        /// <returns>Новая категория расходов</returns>
        public Task<BudgerCategory> AddBudgerCategoryInFamilyAsyns(InputBudgerCategory inputBudger);
        /// <summary>
        /// Удаляет категорию расходов из семьи
        /// </summary>
        /// <param name="BudgerCategoryId">Id категории расходов</param>
        /// <param name="familyId">Id семьи</param>
        /// <returns>Флаг успешности</returns>
        public Task<bool> DeleteBudgerCategoryFromFamilyByIdAsyns(long budgerCategoryId, long familyId);
        /// <summary>
        /// Изменяет категорию доходов в семье по id пользователя
        /// </summary>
        /// <param name="id">Id категории доходов</param>
        /// <param name="userId">Id пользователя</param>
        /// <param name="inputBudgerCategory">Новые данные</param>
        /// <returns>Измененная категория доходов</returns>
        public Task<BudgerCategory> CorrectBudgerCategoryFromUserByIdAsyns(long id, long userId, InputBudgerCategory inputBudgerCategory);
        #endregion
    }
}
