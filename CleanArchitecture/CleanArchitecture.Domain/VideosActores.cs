﻿using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class VideosActores : BaseDomainModel
    {
        public int VideoId { get; set; }
        public int ActorId { get; set; }
    }
}
