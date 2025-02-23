﻿using Api_budger.Models.Abstractions;
using Api_budger.Models.clients;

namespace Api_budger.Models.input
{
    public class OutputUser
    {
        /// <summary>
        /// PK user
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string? Soname { get; set; }
        /// <summary>
        /// Ид пользователя в телеграмме
        /// </summary>
        public long TelegramId { get; set; }
        public Role? Role { get; set; }
        public Family? Family { get; set; }

    }
}
