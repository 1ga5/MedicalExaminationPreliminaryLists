﻿using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Share.DTOs;

namespace MedicalExaminationPreliminaryLists.Api.Application.Mappers
{
    public static class ManualMapper
    {
        public static ZAP ToEntity(this ZAPModel zapModel) => new ZAP
        {
            ZAPNumber = zapModel.ZAPNumber,
            Year = zapModel.Year,
            Surname = zapModel.Surname,
            Name1 = zapModel.Name1,
            Name2 = zapModel.Name2,
            Birthday = zapModel.Birthday,
            TelephoneNumber = zapModel.TelephoneNumber
        };

        public static DispensaryObservation ToEntity(this DispensaryObservationModel dispensaryObservationModel) => new DispensaryObservation
        {
            Number = dispensaryObservationModel.Number,
            MedProfileId = dispensaryObservationModel.MedProfileId,
            DiagnosisCode = dispensaryObservationModel.DiagnosisCode,
            BeginDate = dispensaryObservationModel.BeginDate,
            EndDate = dispensaryObservationModel.EndDate,
            EndReason = dispensaryObservationModel.EndReason,
        };
    }
}
