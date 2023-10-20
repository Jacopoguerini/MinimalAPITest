using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
	private readonly ISqlDataAccess _sqlDataAccess;

	public UserData(ISqlDataAccess sqlDataAccess)
	{
		_sqlDataAccess = sqlDataAccess;
	}

	public Task<IEnumerable<UserModel>> GetUsers() =>
		_sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

	public async Task<UserModel?> GetUser(int id)
	{
		IEnumerable<UserModel> results = await _sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUser_Get",
			new { Id = id });

		return results.FirstOrDefault();
	}

	public Task InsertUser(UserModel user) =>
		_sqlDataAccess.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });

	public Task UpdateUser(UserModel user) =>
		_sqlDataAccess.SaveData("dbo.spUser_Update", user);

	public Task DeleteUser(int id) =>
		_sqlDataAccess.SaveData("dbo.spUser_Delete", new { Id = id });
}