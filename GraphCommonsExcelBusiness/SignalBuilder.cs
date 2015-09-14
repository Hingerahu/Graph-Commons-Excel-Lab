using GraphCommonsExcelBusiness.Models;
using GraphCommonsExcelBusiness.Models.GraphCommons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GraphCommonsExcelBusiness
{
    public class SignalBuilder
    {
        public List<Signal> BuildSignals(Edge edge,DataTable source)
        {
            var signals = source.AsEnumerable().Select(x => 
                new Signal 
                { 
                    action = "edge_create",
                    from_name = x.Field<string>(edge.From),
                    to_name = x.Field<string>(edge.To),
                    from_type = edge.From.ToString(),
                    to_type = edge.To.ToString(),
                    weight = 1,
                    name = edge.Relation
                }).ToList();

            return signals;
        }

        public GraphRequest BuildGraph(DataTable source, List<Edge> edges)
        {
            var signals = new List<Signal>();
            foreach (var edge in edges)
            {
                signals.AddRange(BuildSignals(edge, source));
            }

            var graph = new GraphRequest
            {
                description = "test",
                name = "new graph",
                status = 0,
                signals = signals
            };

            return graph;
        }
    }
}
