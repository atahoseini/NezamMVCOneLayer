using NezamMVCOneLayer.DataAccess.Repository.IRepository;
using NezamMVCOneLayer.Models;
using NezamMVCOneLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NezamMVCOneLayer.Services.Members
{
    public interface IGetCheckupUsersService
    {
        List<MemberAuth> Execute(int logedInUserId);
    }

    public class GetCheckupUsersService : IGetCheckupUsersService
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCheckupUsersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<MemberAuth> Execute(int logedInUserId)
        {
            var logedInUser = unitOfWork.Member.GetFirstOrDefault(x => x.Id == logedInUserId);

            var allUsers = MemberDetail(logedInUser);

            return allUsers;
        }
        #region private methods
        public List<MemberAuth> MemberDetail(Member membre)
        {

            #region LIST

            List<string> lstFatherName = new List<string>();
            List<string> lstMotherName = new List<string>();
            List<string> lstSHSH = new List<string>();
            List<MemberAuth> MemberAuths = new List<MemberAuth>();

            List<int> fi = RandomList(1, 20, 8);

            lstFatherName.Insert(0, membre.FatherFirstName);
            for (int i = 1; i < 8; i++)
            {

                var tmpName = SD.ListOFFirstName[fi[i]];
                if (tmpName != membre.FatherFirstName)
                {
                    lstFatherName.Insert(i, tmpName);
                    if (lstFatherName.Count >= 4)
                        break;
                }
            }
            lstFatherName = Randomize(lstFatherName);



            lstMotherName.Insert(0, membre.MotherLastName);
            for (int i = 1; i < 8; i++)
            {
                var tmpName = SD.ListOFFamily[fi[i]];
                if (tmpName != membre.MotherLastName)
                {
                    lstMotherName.Insert(i, tmpName);
                    if (lstMotherName.Count >= 4)
                        break;
                }
            }
            lstMotherName = Randomize(lstMotherName);



            lstSHSH.Insert(0, membre.Shsh);
            for (int i = 1; i < 8; i++)
            {
                var tmpName = SD.ListOFSHSH[fi[i]].ToString();
                if (tmpName.ToString() != membre.Shsh.ToString())
                {
                    lstSHSH.Insert(i, tmpName.ToString());
                    if (lstSHSH.Count >= 4)
                        break;
                }
            }
            lstSHSH = Randomize(lstSHSH);

            #endregion


            for (int i = 0; i < lstFatherName.Count; i++)
            {
                MemberAuth memberAuth = new MemberAuth();
                memberAuth.id = i + 1;
                memberAuth.FatherName = lstFatherName[i];
                if (lstFatherName[i] == membre.FatherFirstName)
                    memberAuth.IsFather = true;
                else
                    memberAuth.IsFather = false;
                memberAuth.MotherName = lstMotherName[i];
                if (lstMotherName[i] == membre.MotherLastName)
                    memberAuth.IsMother = true;
                else
                    memberAuth.IsMother = false;

                memberAuth.ShSH = lstSHSH[i];
                if (lstSHSH[i] == membre.Shsh)
                    memberAuth.IsSHSH = true;
                else
                    memberAuth.IsSHSH = false;
                MemberAuths.Add(memberAuth);
            }

            return MemberAuths;
        }


        private List<int> RandomList(int min, int max, int count)
        {
            List<int> listNumbers = new List<int>();
            Random random = new Random();
            listNumbers.AddRange(Enumerable.Range(min, max)
                                .OrderBy(i => random.Next())
                                .Take(count));
            return listNumbers;
        }

        public static List<T> Randomize<T>(List<T> list)
        {
            List<T> randomizedList = new List<T>();
            Random rnd = new Random();
            while (list.Count > 0)
            {
                int index = rnd.Next(0, list.Count); //pick a random item from the master list
                randomizedList.Add(list[index]); //place it at the end of the randomized list
                list.RemoveAt(index);
            }
            return randomizedList;
        }
        #endregion
    }
}
