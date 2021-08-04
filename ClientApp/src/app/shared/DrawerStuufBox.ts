

export interface IDrawerStuffBox{
  name: string,
  url: string,
  icon: string
}

export const DrawerStuffBox: IDrawerStuffBox[] = [
  {
    name: "Написать пост",
    url: "PersonalAccount/createPost",
    icon: "create"
  },
  {
    name: "Общие посты",
    url: "PersonalAccount/allPosts",
    icon: "create"
  }
]
