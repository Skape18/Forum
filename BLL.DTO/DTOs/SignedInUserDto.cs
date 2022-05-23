using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.DTOs
{
    public class SignedInUserDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        public int[] LikedToUserIds { get; set; }
        public int[] DislikedToUserIds { get; set; }
        public SignedInUserDto(UserDto user, string token, int[] likedToUserIds, int[] dislikedToUserIds)
        {
            User = user;
            Token = token;
            LikedToUserIds = likedToUserIds;
            DislikedToUserIds = dislikedToUserIds;
        }
    }
}
