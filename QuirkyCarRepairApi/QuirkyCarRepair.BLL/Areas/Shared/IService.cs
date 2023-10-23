namespace QuirkyCarRepair.BLL.Areas.Shared
{
    public interface IService<Entity>
    {
        public ICollection<Entity> GetAll();

        public Entity Get(int id);

        public Entity Creat(Entity model);

        public void Update(int id, Entity model);

        public void Delete(int id);
    }
}