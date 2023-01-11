using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Visitor
{
    public interface IBikeElement
    {
        void Accept(IVisitor visitor);
    }
}
