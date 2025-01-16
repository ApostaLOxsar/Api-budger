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
        Task<Role> CorrectRoleByIdAsyns(long RoleId, User inputRole);
        /// <summary>
        /// Изменяет семью по Id
        /// </summary>
        /// <param name="FamilyId">Id семьи</param>
        /// <param name="inputFamily">Новые данные</param>
        /// <returns>Измененная семья</returns>
        Task<Family> CorrectFamilyByIdAsyns(long FamilyId, User inputFamily);

    }
}
