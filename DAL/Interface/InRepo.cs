using System.Collections.Generic;

namespace DAL.Interface
{
    public interface InRepo<classType, idType, returnType>
    {
        List<classType> All();
        classType get(idType key);
        returnType create(classType obj);
        bool update(classType obj);
        bool delete(idType key);

    }
}
