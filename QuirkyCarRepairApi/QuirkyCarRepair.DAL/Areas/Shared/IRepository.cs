namespace QuirkyCarRepair.DAL.Areas.Shared
{
    public interface IRepository<Model>
    {
        public ICollection<Model> GetAll();

        public Model? Get(int id);

        public Model Creat(Model model);

        public void Update(Model model);

        public void Delete(Model model);

        public bool Exist(int id);
    }
}