﻿namespace ForgetTraffic.DataTypes.Wrappers
{
    /*
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *              Author       :  Fernando Vaz
     *              Date         :  30-05-2011  
     *              Name         :  IForgetTrafficWrapper
     *              Description  :  Manage the User Entities
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *                      Revison List
     *--------------------------------------------------------------------------------------             
     * Author           |       Date                
     * 
     * 
     * */

    public interface IForgetTrafficWrapper<E, K>
    {
        K TransformTo(E tInput);
    }
}