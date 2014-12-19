﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using Contracts;
using ContractConfigurator.Parameters;

namespace ContractConfigurator
{
    /*
     * ParameterFactory wrapper for ReachBiome ContractParameter.
     */
    public class ReachBiomeFactory : ParameterFactory
    {
        protected string biome { get; set; }

        public override bool Load(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.Load(configNode);

            // Get biome
            if (!configNode.HasValue("biome"))
            {
                valid = false;
                LoggingUtil.LogError(this.GetType(), ErrorPrefix(configNode) +
                    ": missing required value 'biome'.");
            }
            biome = configNode.GetValue("biome");

            return valid;
        }

        public override ContractParameter Generate(Contract contract)
        {
            return new ReachBiomeCustom(biome, title);
        }
    }
}
