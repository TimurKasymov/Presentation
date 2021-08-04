


export interface IlistOfLinks {
  name: string,
  url: string,
  icon: string
}
export interface ServerMessage {message: string}
export interface ServerMessageWithToken {message: string; token: string; refreshToken: string}

export interface IAccount{
  Role: number,
  Name: string,
  Surname: string,
  About: string,
  Posts: [],
  Password: string,
  Email: string,
}
export interface IAccountChanging{
  Name: string,
  Surname: string,
  About: string,
  Password: string,
  PastPassword: string,
  Email: string,
}
export interface RefreshToken{
  newToken: string,
  refreshToken: string
  _account: IAccount
}
export interface AccountMassege{
  account: IAccount
}

export interface IPost{
  title: string
  text: string
  likes: number
  picture: string
  id: number
  date: string
}
