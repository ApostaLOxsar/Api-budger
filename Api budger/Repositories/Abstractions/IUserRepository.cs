using Api_budger.Models.clients;

namespace Api_budger.Repositories.Abstractions
{
    public interface IUserRepository
    {
        /// <summary>
        /// Возвращает всех пользователей в БД
        /// </summary>
        /// <returns>Список пользователей</returns>
        Task<List<User>?> GetAllUsersAsync();
        /// <summary>
        /// Добавляет пользователя в БД
        /// </summary>
        /// <param name="inputUser">Данные нового пользователя</param>
        /// <returns>Добавленый пользователь</returns>
        Task<User> AddUserAsyns(User inputUser);
        /// <summary>
        /// Возвращает пользователя по Id
        /// </summary>
        /// <param name="UserId">Id пользователя</param>
        /// <returns>Пользователь</returns>
        Task<User?> GetUserByIdAsync(long UserId);
        /// <summary>
        /// Удаляет пользователя по Id
        /// </summary>
        /// <param name="UserId">Id пользователя</param>
        /// <returns>Флаг успешности</returns>
        Task<bool> DeleteUserByIdAsync(long UserId);
        /// <summary>
        /// Возвращает все роли в БД
        /// </summary>
        /// <returns>Список ролей</returns>
        Task<List<Role>?> GetAllRoleAsync();
        /// <summary>
        /// Возвращает роль по Id
        /// </summary>
        /// <param name="RoleId">Id роли</param>
        /// <returns>Роль</returns>
        Task<Role?> GetRoleByIdAsync(long RoleId);
        /// <summary>
        /// Добавляет роль в БД
        /// </summary>
        /// <param name="inputRole">Входные данные новой роли</param>
        /// <returns>Добавленая роль</returns>
        Task<Role> AddRoleAsyns(Role inputRole);
        /// <summary>
        /// Удаляет роль по Id
        /// </summary>
        /// <param name="RoleId">Id роли</param>
        /// <returns>флаг успешности</returns>
        Task<bool> DeleteRoleByIdAsyns(long RoleId);
        /// <summary>
        /// Возвращает все семьи в БД
        /// </summary>
        /// <returns>Список семей в БД</returns>
        Task<List<Family>?> GetAllFamilyAsync();
        /// <summary>
        /// Семья по Id
        /// </summary>
        /// <param name="familyId">Id семьи</param>
        /// <returns>Данные семьи</returns>
        Task<Family?> GetFamilyByIdAsync(long familyId);

        /// <summary>
        /// Id семьи по user Id
        /// </summary>
        /// <param name="familyId">Id семьи</param>
        /// <returns>Id семьи</returns>
        Task<long> GetFamilyIdByUserIdAsync(long userId);
        /// <summary>
        /// Семья по Id пользователя
        /// </summary>
        /// <param name="userId">Id семьи</param>
        /// <returns>Данные семьи</returns>
        Task<Family?> GetFamilyByUserIdAsync(long userId);
        /// <summary>
        /// Добавляет семью
        /// </summary>
        /// <param name="inputFamily">Данные семьи</param>
        /// <returns>Добавленая семья</returns>
        Task<Family> AddFamilyAsyns(Family inputFamily);
        /// <summary>
        /// Удаляет семью по Id
        /// </summary>
        /// <param name="familyId">Id семьи</param>
        /// <returns>Флаг успешности</returns>
        Task<bool> DeleteFamilyByIdAsyns(long familyId);
        /// <summary>
        /// Изменяет юзера по Id
        /// </summary>
        /// <param name="UserId">Id юзера</param>
        /// <param name="inputUser">Новые данные</param>
        /// <returns>Измененный юзер</returns>
        Task<User> CorrectUserByIdAsyns(long UserId, User inputUser);
        /// <summary>
        /// Изменяет роль по Id
        /// </summary>
        /// <param name="RoleId">Id роли</param>
        /// <param name="inputRole">Новые данные</param>
        /// <returns>Измененная роль</returns>
        Task<Role> CorrectRoleByIdAsyns(long RoleId, Role inputRole);
        /// <summary>
        /// Изменяет семью по Id
        /// </summary>
        /// <param name="FamilyId">Id семьи</param>
        /// <param name="inputFamily">Новые данные</param>
        /// <returns>Измененная семья</returns>
        Task<Family> CorrectFamilyByIdAsyns(long FamilyId, Family inputFamily);
        /// <summary>
        /// получает хэш пароля по ид пользователя
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns>хэш пароля</returns>
        Task<string> GetHashByUserIdAsync(long userId);
        /// <summary>
        /// Получает юзера по емайл
        /// </summary>
        /// <param name="email">емайл</param>
        /// <returns>юзер</returns>
        Task<User> GetUserByEmailAsync(string email);

        /// <summary>
        /// Получает юзера по телеграм Ид
        /// </summary>
        /// <param name="telegramId">telegram id</param>
        /// <returns>юзер</returns>
        Task<User> GetUserByTelegramIdAsync(long telegramId);
        /// <summary>
        /// Получает юзера по Ид семьи
        /// </summary>
        /// <param name="familyId">familyId id</param>
        /// <returns>юзер Id</returns>
        Task<long> GetUserIdByFamilyAsync(long familyId);

    }
}
