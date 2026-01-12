using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class CreateWorkDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = default!;

    [Required]
    [MinLength(1, ErrorMessage = "At least one description point is required.")]
    public List<string> Descriptions { get; set; } = new();

    [Required]
    public DateTime StartedAt { get; set; }

    public DateTime? LeftAt { get; set; }

    [Required]
    public bool IsWorking { get; set; }

    [Required]
    [MaxLength(200)]
    public string WorkedAt { get; set; } = default!;
}
public class UpdateWorkDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = default!;
    [Required]
    [MinLength(1, ErrorMessage = "At least one description point is required.")]
    public List<string> Descriptions { get; set; } = new();
    [Required]
    public DateTime StartedAt { get; set; }
    public DateTime? LeftAt { get; set; }
    [Required]
    public bool IsWorking { get; set; }
    [Required]
    [MaxLength(200)]
    public string WorkedAt { get; set; } = default!;
}

public class WorkResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public List<string> Descriptions { get; set; } = new();
    public DateTime StartedAt { get; set; }
    public DateTime? LeftAt { get; set; }
    public bool IsWorking { get; set; }
    public string WorkedAt { get; set; } = default!;
}
