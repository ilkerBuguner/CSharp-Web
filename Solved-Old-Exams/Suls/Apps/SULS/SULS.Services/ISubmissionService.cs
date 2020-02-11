using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public interface ISubmissionService
    {
        void Create(string code, string problemId, string userId);

        void Delete(string id);
    }
}
