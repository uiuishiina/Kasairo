
namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing
{
    /// <summary>
    /// OtherObjectを継承している、player側が衣類を持っているかどうか調べる必要があるクラスの親クラス
    /// </summary>
    public class CheckClothingObject : OtherObject
    {
        /// <summary>
        /// player側が衣類を持っているかどうかの確認(DeskとMashineObjectで関数の中身を変えたいので仮想関数にしている)
        /// </summary>
        /// <param name="ownedClothing">playerの衣類</param>
        /// <returns>持っているかどうか(持っていたらtrue、なかったらfalse)</returns>
        protected virtual bool Check(OwnedClothing ownedClothing)
        {
            Clothes it = ownedClothing.OwnedClothes;

            return it != null;
        }
    }
}


