
namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.PutableClothingObject
{
    /// <summary>
    /// 机のクラス
    /// </summary>
    public class Desk : PutableClothingObject
    {
        /// <summary>
        /// playerが机に触れた瞬間に発動する机の関数
        /// </summary>
        /// <param name="myclothe">playerの衣類のデータ</param>
        public override void ObjectAction(OwnedClothing myclothe)
        {
            Check(myclothe);
        }
    }
}