using AutoMapper;
using SIS_ITELEC3.Dtos;
using SIS_ITELEC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Instructors, InstructorsDto>();
            Mapper.CreateMap<InstructorsDto, Instructors>();

            Mapper.CreateMap<Courses, CoursesDto>();
            Mapper.CreateMap<CoursesDto, Courses>();

            Mapper.CreateMap<Subjects, SubjectsDto>();
            Mapper.CreateMap<SubjectsDto, Subjects>();

            Mapper.CreateMap<Students, StudentsDto>();
            Mapper.CreateMap<StudentsDto, Students>();

            Mapper.CreateMap<Grades, GradesDto>();
            Mapper.CreateMap<GradesDto, Grades>();
        }
    }
}